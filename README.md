# MovieLibrary

Серверное приложение для управления коллекцией фильмов с возможностью оставлять отзывы и оценки. Реализовано на .NET 9 с использованием чистой архитектуры и полной контейнеризацией в Docker.

![Статус разработки](https://img.shields.io/badge/status-active-brightgreen)
![.NET Version](https://img.shields.io/badge/.NET-9.0-512BD4?logo=.net)
![Docker](https://img.shields.io/badge/Docker-Ready-2496ED?logo=docker)

## Содержание
- [Технологии](#технологии)
- [Использование](#использование)
- [Разработка](#разработка)
- [Deploy и CI/CD](#deploy-и-cicd)
- [FAQ](#faq)
- [To do](#to-do)
- [Команда проекта](#команда-проекта)

## Технологии

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
```bash
# Клонируйте репозиторий
git clone https://github.com/sgc433/MovieLibrary.git
cd MovieLibrary

# Запустите контейнеры
docker-compose up -d
```
После запуска API будет доступно по адресу `http://localhost:5281/swagger/index.html`, где вы можете ознакомиться со всеми эндпоинтами и протестировать их.

**Пример запроса для получения списка фильмов:**

```http
GET /api/movies
Host: localhost:5281
Authorization: Bearer <ваш_jwt_токен>
```

**Регистрация нового пользователя:**

```http
POST /api/User/register
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "securePassword123"
}
```

**Добавление отзыва к фильму:**

```http
POST /api/Review
Content-Type: application/json
Authorization: Bearer <ваш_jwt_токен>
{
  "movieName": "somemovie",
  "username": "someuser",
  "rating": 10,
  "comment": "Good film!",
  "dateAdded": "2026-03-23T16:41:35.051Z"
}
```

## Разработка

### Требования

Для локальной разработки без Docker необходимы:
- .NET 8 SDK
- PostgreSQL (локально или в контейнере)
- Visual Studio 2022 / Rider / VS Code

### Установка зависимостей

```bash
Восстановите NuGet-пакеты:

dotnet restore
```

### Настройка базы данных

```json
Обновите строку подключения в `MovieLibrary/appsettings.json`:

{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=MovieLibraryDb;Username=postgres;Password=yourpassword"
  }
}
```

### Применение миграций

```bash
dotnet ef database update --project MovieLibrary.DataAccess --startup-project MovieLibrary
```

## Deploy и CI/CD

Проект полностью контейнеризирован, что упрощает развертывание.

**Docker образ:**

```bash
docker build -t movielibrary .
```

**Запуск с Docker Compose:**

```bash
docker-compose up -d
```

**Планируемый CI/CD пайплайн (GitHub Actions):**
- Автоматическая сборка при пуше в main
- Запуск тестов
- Сборка Docker-образа
- Публикация в контейнерный реестр (Docker Hub / GitHub Container Registry)
- Деплой на staging-окружение

## FAQ

### Зачем вы разработали этот проект?

Для портфолио и практики в построении backend-приложений на .NET с использованием современных подходов: чистая архитектура, контейнеризация, REST API. Также проект демонстрирует навыки, которые могут быть полезны при стажировке в компании, активно использующей .NET стек.

### Какие возможности API доступны?

- CRUD операции с фильмами (требует аутентификации для изменения)
- Аутентификация и регистрация пользователей (JWT)
- Добавление, просмотр и удаление отзывов
- Пагинация и фильтрация при получении списка фильмов

### Можно ли использовать другую базу данных?

Да, Entity Framework Core позволяет использовать любую поддерживаемую БД (SQL Server, SQLite, MySQL и др.). Для этого потребуется изменить строку подключения и установить соответствующий пакет.

### Как запустить проект без Docker?

Установите .NET 9 SDK и PostgreSQL локально, настройте строку подключения в `appsettings.json`, примените миграции и запустите `dotnet run --project MovieLibrary`.

## To do

- [ ] Написать модульные и интеграционные тесты (xUnit)
- [ ] Добавить Redis для кэширования популярных фильмов
- [ ] Настроить CI/CD через GitHub Actions

## Команда проекта

- **sgc433** — разработчик, проектирование архитектуры, настройка контейнеризации
