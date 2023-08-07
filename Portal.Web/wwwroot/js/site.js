// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const aciklamaMetinKutusu = document.querySelector(".etkinlik-aciklama");
const karakterSayisi = document.querySelector(".sayi");

aciklamaMetinKutusu.addEventListener("input", function () {
    const kalanKarakter = 3000 - this.value.length;
    karakterSayisi.textContent = kalanKarakter;
});
