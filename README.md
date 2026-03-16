# Bullseye API

A C# ASP.NET Core Web API backend for Bullseye, a mock stock trading simulation. Manages fake stock data, price simulation, and portfolio tracking entirely in memory.

This project was built as a proof of concept to demonstrate proficiency with C# API development patterns.

## Tech Stack

- .NET 10
- ASP.NET Core Web API
- Swagger / OpenAPI

## Features

- Serves a list of 50 fake stocks
- Simulates live price movement every 5 seconds
- Tracks 24-hour price history per stock
- Manages user portfolio — holdings, cash balance, buy/sell transactions
- Tracks portfolio value over time

## Architecture

The API follows a clean service-based architecture:

- `Controllers/` — handle HTTP requests and responses
- `Services/` — own all business logic and in-memory data
- `Models/` — plain C# classes representing domain objects

### Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/stocks` | Get all stocks |
| GET | `/api/stocks/{ticker}` | Get a single stock |
| GET | `/api/stocks/{ticker}/history` | Get 24-hour price history |
| GET | `/api/portfolio` | Get holdings and cash balance |
| GET | `/api/portfolio/history` | Get portfolio value history |
| POST | `/api/portfolio/buy` | Buy shares |
| POST | `/api/portfolio/sell` | Sell shares |

## Getting Started

1. Clone this repo
2. Open `bullseye-api.slnx` in Visual Studio
3. Press **F5** to run
4. Navigate to `https://localhost:7277/swagger` to explore the API

## Known Limitations

This is a proof of concept. In a production version:

- All data would persist in a relational database (e.g. SQL Server with Entity Framework Core)
- Authentication and user accounts would be required
- Stock prices would come from a real market data provider
- The API would be deployed behind HTTPS with proper environment configuration
- Input validation and error handling would be more robust
