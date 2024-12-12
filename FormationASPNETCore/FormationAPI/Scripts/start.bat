docker compose -f docker-compose.test.yml -f docker-compose.yml down
docker compose -f docker-compose.test.yml -f docker-compose.yml up --build -d
rem dotnet ef database update --startup-project Api --project Data
dotnet ef database update
dotnet test --filter "FullyQualifiedName=Test.InitTest.Init"

