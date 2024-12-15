
######### install postgres on a container #########

# create a PostgreSQL container instance with some specific parameter settings
docker run --name localpg -e POSTGRES_PASSWORD=<password> -p 5433:5432 -d postgres:latest -c listen_addresses='*' -c shared_preload_libraries='pg_stat_statements' -c pg_stat_statements.track=all

# connect to the PostgreSQL container instance
psql -h localhost -U postgres

# connect to the container
docker exec -it localpg /bin/bash