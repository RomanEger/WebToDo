﻿// Выбираем кнопку
const btn = document.querySelector(".btn-toggle");
// Выбираем таблицу стилей
const theme = document.querySelector("#theme-link");
// Отслеживаем щелчок по кнопке
btn.addEventListener("click", function () {
    // Если текущий адрес содержит "light-theme.css"
    if (theme.getAttribute("href") == "/css/light-theme.css") {
        // …то переключаемся на "dark-theme.css"
        theme.href = "/css/dark-theme.css";
        // В противном случае… 
    } else {
        // …переключаемся на "light-theme.css"
        theme.href = "/css/light-theme.css";
    }
});