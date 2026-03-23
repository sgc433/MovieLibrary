# MovieLibrary

Серверное приложение для управления коллекцией фильмов с возможностью оставлять отзывы и оценки. Реализовано на .NET 9 с использованием чистой архитектуры и полной контейнеризацией в Docker.

![Статус разработки](https://img.shields.io/badge/status-active-brightgreen)
![.NET Version](https://img.shields.io/badge/.NET-8.0-512BD4?logo=.net)
![Docker](https://img.shields.io/badge/Docker-Ready-2496ED?logo=docker)

## Содержание
- [Технологии](#технологии)
- [Использование](#использование)
- [Разработка](#разработка)
- [Тестирование](#тестирование)
- [Deploy и CI/CD](#deploy-и-cicd)
- [Contributing](#contributing)
- [FAQ](#faq)
- [To do](#to-do)
- [Команда проекта](#команда-проекта)

## Технологики

- **.NET 9** — основная платформа разработки
- **C#** — язык программирования
- **Entity Framework Core** — ORM для работы с базой данных
- **PostgreSQL** — реляционная база данных
- **ASP.NET Core Web API** — построение REST API
- **Docker & Docker Compose** — контейнеризация и оркестрация
- **JWT Bearer** — аутентификация и авторизация
- **Clean Architecture** — архитектурный подход с разделением на слои (Core, Application, DataAccess, Infrastructure, Presentation)

## Использование

Самый простой способ запустить проект — использовать Docker Compose. Это поднимет API и базу данных PostgreSQL одной командой.

# Клонируйте репозиторий
git clone https://github.com/sgc433/MovieLibrary.git
cd MovieLibrary

# Запустите контейнеры
docker-compose up -d

После запуска API будет доступно по адресу http://localhost:5281/swagger/index.html, где вы можете ознакомиться со всеми эндпоинтами и протестировать их.

Пример запроса для получения списка фильмов:
GET /api/movies
Host: localhost:5281
Authorization: Bearer <ваш_jwt_токен>

Регистрация нового пользователя:
POST /api/auth/register
Content-Type: application/json
{
  "email": "user@example.com",
  "password": "securePassword123"
}

Добавление отзыва к фильму:
POST /api/reviews
Content-Type: application/json
Authorization: Bearer <ваш_jwt_токен>
{ 
  "movieId": 1,
  "rating": 5,
  "comment": "Отличный фильм!"
}

Разработка

Требования

Для локальной разработки без Docker необходимы:
.NET 8 SDK
PostgreSQL (локально или в контейнере)
Visual Studio 2022 / Rider / VS Code

Установка зависимостей
Восстановите NuGet-пакеты:
dotnet restore


