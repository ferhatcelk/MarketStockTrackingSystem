/* ==========================================================
   app.js  —  Market Stok Takip Sistemi  |  Web Layer
   Özellikler:
     1. Canvas arka plan partikülleri
     2. Sayfa yüklenince animasyonlu sayaç
     3. IntersectionObserver ile scroll-reveal
     4. Canvas'a stok analiz bar chart çizimi
     5. Navbar scroll efekti
   ========================================================== */

"use strict";

/* ── 1. Arka Plan Partikülleri ─────────────────────────────────────── */
(function initParticles() {
  const canvas = document.getElementById("bgCanvas");
  if (!canvas) return;
  const ctx = canvas.getContext("2d");

  // Parçacık verileri
  const PARTICLE_COUNT = 70;
  const particles = [];

  function resize() {
    canvas.width  = window.innerWidth;
    canvas.height = window.innerHeight;
  }
  resize();
  window.addEventListener("resize", resize);

  // Rastgele renk paleti (indigo / violet / blue)
  const colors = [
    "rgba(99,102,241,",   // indigo
    "rgba(139,92,246,",   // violet
    "rgba(59,130,246,",   // blue
    "rgba(16,185,129,",   // green (az)
  ];

  function rand(min, max) {
    return min + Math.random() * (max - min);
  }

  function createParticle() {
    return {
      x:    rand(0, canvas.width),
      y:    rand(0, canvas.height),
      r:    rand(1, 2.5),
      dx:   rand(-0.3, 0.3),
      dy:   rand(-0.4, -0.1),
      alpha: rand(0.2, 0.7),
      color: colors[Math.floor(Math.random() * colors.length)]
    };
  }

  for (let i = 0; i < PARTICLE_COUNT; i++) {
    particles.push(createParticle());
  }

  function draw() {
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    // Parçacıkları çiz ve bağlantı çizgileri ekle
    particles.forEach((p, i) => {
      // Parçacık
      ctx.beginPath();
      ctx.arc(p.x, p.y, p.r, 0, Math.PI * 2);
      ctx.fillStyle = p.color + p.alpha + ")";
      ctx.fill();

      // Yakın parçacıklarla bağlantı
      for (let j = i + 1; j < particles.length; j++) {
        const q = particles[j];
        const dist = Math.hypot(p.x - q.x, p.y - q.y);
        if (dist < 120) {
          ctx.beginPath();
          ctx.moveTo(p.x, p.y);
          ctx.lineTo(q.x, q.y);
          const opacity = (1 - dist / 120) * 0.08;
          ctx.strokeStyle = `rgba(99,102,241,${opacity})`;
          ctx.lineWidth = 0.8;
          ctx.stroke();
        }
      }

      // Hareket
      p.x  += p.dx;
      p.y  += p.dy;
      p.alpha += rand(-0.002, 0.002);
      p.alpha = Math.max(0.1, Math.min(0.8, p.alpha));

      // Sınır dışına çıkarsa sıfırla
      if (p.y < -10) {
        p.y = canvas.height + 10;
        p.x = rand(0, canvas.width);
      }
      if (p.x < -10) p.x = canvas.width + 10;
      if (p.x > canvas.width + 10) p.x = -10;
    });

    requestAnimationFrame(draw);
  }

  draw();
})();

/* ── 2. Animasyonlu Sayaç ──────────────────────────────────────────── */
function animateCounter(el, target, duration, suffix) {
  const startTime = performance.now();

  function update(now) {
    const elapsed  = now - startTime;
    const progress = Math.min(elapsed / duration, 1);
    // Ease out quad
    const eased    = 1 - (1 - progress) * (1 - progress);
    const current  = Math.round(eased * target);

    el.textContent = current + suffix;
    if (progress < 1) requestAnimationFrame(update);
  }

  requestAnimationFrame(update);
}

/* ── 3. IntersectionObserver — Scroll Reveal + Sayaç Tetikleyici ──── */
function initReveal() {
  // Genel reveal animasyonu
  const revealEls = document.querySelectorAll(
    ".feat-card, .arch-layer, .tech-card, .stat-block, .hstat-card, .chart-wrapper, .lang-section"
  );

  revealEls.forEach(el => el.classList.add("reveal"));

  const revealObserver = new IntersectionObserver(
    (entries) => {
      entries.forEach((entry, idx) => {
        if (entry.isIntersecting) {
          // Kademeli gecikmeli animasyon
          const delay = (idx % 6) * 80;
          setTimeout(() => entry.target.classList.add("visible"), delay);
          revealObserver.unobserve(entry.target);
        }
      });
    },
    { threshold: 0.12 }
  );

  revealEls.forEach(el => revealObserver.observe(el));

  // Sayaç tetikleyici — istatistik bölümü
  const counterEls = document.querySelectorAll("[data-count]");
  const counterObserver = new IntersectionObserver(
    (entries) => {
      entries.forEach(entry => {
        if (entry.isIntersecting) {
          const el      = entry.target.querySelector(".hstat-num, .stat-num");
          const target  = parseInt(entry.target.dataset.count, 10);
          const suffix  = entry.target.dataset.suffix || "";
          if (el) animateCounter(el, target, 1400, suffix);
          counterObserver.unobserve(entry.target);
        }
      });
    },
    { threshold: 0.5 }
  );

  counterEls.forEach(el => counterObserver.observe(el));
}

/* ── 4. Stok Bar Chart (Canvas 2D) ────────────────────────────────── */
function drawStockChart() {
  const canvas = document.getElementById("stockChart");
  if (!canvas) return;

  canvas.height = 220;
  const ctx = canvas.getContext("2d");

  // Örnek veriler (Python analiz scripti çıktısından alınmış)
  const data = [
    { label: "Süt Ürünleri",  value: 48, color: "#6366f1" },
    { label: "Ekmek & Fırın", value: 32, color: "#3b82f6" },
    { label: "İçecekler",     value: 75, color: "#10b981" },
    { label: "Temizlik",      value: 21, color: "#f59e0b" },
    { label: "Atıştırmalık",  value: 63, color: "#8b5cf6" },
    { label: "Konserve",      value: 14, color: "#ef4444" },
  ];

  const W   = canvas.width;
  const H   = canvas.height;
  const PAD = { top: 20, right: 20, bottom: 50, left: 40 };
  const chartW = W - PAD.left - PAD.right;
  const chartH = H - PAD.top - PAD.bottom;
  const maxVal = Math.max(...data.map(d => d.value));

  // Arka plan temizle
  ctx.clearRect(0, 0, W, H);

  // Yatay ızgara çizgileri
  for (let i = 0; i <= 4; i++) {
    const y = PAD.top + (chartH / 4) * i;
    ctx.beginPath();
    ctx.moveTo(PAD.left, y);
    ctx.lineTo(W - PAD.right, y);
    ctx.strokeStyle = "rgba(255,255,255,0.05)";
    ctx.lineWidth = 1;
    ctx.stroke();

    // Y ekseni etiketleri
    const val = Math.round(maxVal - (maxVal / 4) * i);
    ctx.fillStyle = "rgba(148,163,184,0.7)";
    ctx.font = "10px Inter, sans-serif";
    ctx.textAlign = "right";
    ctx.fillText(val, PAD.left - 6, y + 4);
  }

  // Barlar
  const barW   = chartW / data.length;
  const barPad = barW * 0.22;

  data.forEach((d, i) => {
    const barHeight = (d.value / maxVal) * chartH;
    const x = PAD.left + i * barW + barPad;
    const y = PAD.top + chartH - barHeight;
    const w = barW - barPad * 2;

    // Gölge / glow efekti
    ctx.shadowColor = d.color;
    ctx.shadowBlur = 12;

    // Gradient dolgu
    const grad = ctx.createLinearGradient(x, y, x, y + barHeight);
    grad.addColorStop(0, d.color);
    grad.addColorStop(1, d.color + "44");
    ctx.fillStyle = grad;

    // Yuvarlatılmış üst köşeler
    const radius = 5;
    ctx.beginPath();
    ctx.moveTo(x + radius, y);
    ctx.lineTo(x + w - radius, y);
    ctx.quadraticCurveTo(x + w, y, x + w, y + radius);
    ctx.lineTo(x + w, y + barHeight);
    ctx.lineTo(x, y + barHeight);
    ctx.lineTo(x, y + radius);
    ctx.quadraticCurveTo(x, y, x + radius, y);
    ctx.closePath();
    ctx.fill();

    ctx.shadowBlur = 0;

    // Bar üstüne değer
    ctx.fillStyle = "#f8fafc";
    ctx.font = "bold 11px Inter, sans-serif";
    ctx.textAlign = "center";
    ctx.fillText(d.value, x + w / 2, y - 6);

    // X ekseni etiketi
    ctx.fillStyle = "rgba(148,163,184,0.8)";
    ctx.font = "9.5px Inter, sans-serif";
    ctx.fillText(d.label, x + w / 2, H - PAD.bottom + 16);
  });
}

/* ── 5. Navbar Scroll Efekti ───────────────────────────────────────── */
function initNavbar() {
  const nav = document.getElementById("navbar");
  if (!nav) return;

  window.addEventListener("scroll", () => {
    if (window.scrollY > 40) {
      nav.style.background = "rgba(8,12,26,0.95)";
      nav.style.borderBottomColor = "rgba(255,255,255,0.1)";
    } else {
      nav.style.background = "rgba(8,12,26,0.7)";
      nav.style.borderBottomColor = "rgba(255,255,255,0.08)";
    }
  }, { passive: true });
}

/* ── 6. Aktif Nav Linki ────────────────────────────────────────────── */
function initActiveLink() {
  const sections = document.querySelectorAll("section[id]");
  const navLinks = document.querySelectorAll(".nav-links a");

  const observer = new IntersectionObserver(
    (entries) => {
      entries.forEach(entry => {
        if (entry.isIntersecting) {
          navLinks.forEach(a => a.classList.remove("active"));
          const active = document.querySelector(`.nav-links a[href="#${entry.target.id}"]`);
          if (active) active.classList.add("active");
        }
      });
    },
    { rootMargin: "-40% 0px -55% 0px" }
  );

  sections.forEach(s => observer.observe(s));
}

/* ── Başlatma ──────────────────────────────────────────────────────── */
document.addEventListener("DOMContentLoaded", () => {
  initReveal();
  initNavbar();
  initActiveLink();

  // Chart: canvas boyutu ayarlandıktan sonra çiz
  const chartCanvas = document.getElementById("stockChart");
  if (chartCanvas) {
    const resizeChart = () => {
      chartCanvas.width = chartCanvas.parentElement.clientWidth - 48;
      drawStockChart();
    };
    resizeChart();
    window.addEventListener("resize", resizeChart, { passive: true });
  }
});
