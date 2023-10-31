# build docker compose
build:
	docker-compose build

# start
start:
	docker-compose up -d
    
# stop
stop:
	docker-compose down
    
# restart
restart:
	docker-compose restart
    
# logs
logs:
	docker-compose logs -f
    
# ps
ps:
	docker-compose ps
 
# build and start
up: build start
