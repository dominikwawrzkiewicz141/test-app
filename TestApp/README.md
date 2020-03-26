1. Build Dockerfiles
docker build --rm -f "AppA.Dockerfile" -t appa:latest "."
docker build --rm -f "AppB.Dockerfile" -t appb:latest "."
2. docker pull postgres
3. docker-compose -f "docker-compose.yml" up -d --build
4. 

AppA:
http://localhost:10000/api/films

GET api/films
POST api/films
{
	"Title": "LoTR 4"
}

GET /api/carsproxy
POST api/carsproxy
{
	"Model": "Audi A8"
}

Postman -> http://localhost:10000/api/carsproxy (appA) -> http://localhost:10001/api/cars (appB) -> PostgreSQL

AppB:
http://localhost:10001/api/cars

GET api/cars
POST api/cars
{
	"Model": "Audi A8"
}

GET api/filmsproxy
POST api/filmsproxy
{
	"Title": "LoTR 4"
}

Postman -> http://localhost:10001/api/filmsproxy (appB) -> http://localhost:10000/api/films (appA) -> PostgreSQL
