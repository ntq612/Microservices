Team BackEnd Web Api .NET Microservice


Udemy
kelvincoder@gmail.com
12345678x@X


 --Spring Boot

CQRS

catalog -- postgre

basket -- redis - postgre

discount -- sqlite

ordering -- sql server

end with rabbitMQ or call direct

client app---API gateway---YARP--- microservice

Architectures: layered, ddd,
vertical slide, clean

patterns: solid, cqrs, mediator, decorator, 
options, pub/sub, caching, api gateway

DB: transactional document db, postgre, redis, 
	sqlite, SQL Server

Libraries: Carter, Marten, MediatR,
Mapster, MassTransit, FluentValidation,
EF Core, Refit

Communications: Sync: gRPC, 
Async: Publish/ Subcribe
pattern with MassTransit and RabbitMQ,
YARP Api gateway

Project Structure

Benefits:
Agility, Innovation and time-to-market
flexible scalability
Small, focused teams
Small and separated code base

Challenges of microservice:

Complexity, Network problems and latency
Development and testing
Data intergrity

When use Microservice:
Have a "Really Good Reason" for implement mic
Iterate with small changes and keep the single-
process Monolith as your default

Required to Independently deploy new
functionality with Zero Downtime

Required to Independently Scale a Portion of App

        Local Env     Docker Env    Docker Inside
catalog 5000 - 5050   6000 - 6060   8080 - 8081
basket  5001 - 5051   6001 - 6061   8080 - 8081
discount 5002 - 5052  6002 - 6062   8080 - 8081
ordering 5003 - 5053  6003 - 6063


Vertical Slice architecture
Clean Architecture

CQRS - Command/ Query --> Read and Write Database




