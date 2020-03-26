#!/bin/bash
psql -v ON_ERROR_STOP=1 --username "postgres" -d "postgres"  <<-EOSQL
CREATE SCHEMA appA
    CREATE TABLE films (id serial, title text);

CREATE SCHEMA appB
    CREATE TABLE cars (id serial, model text);
EOSQL