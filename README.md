# modernization-unicorn-store
Buy some Magical Unicorns and deploy the Unicon Store to a Docker container.
modernization-unicorn-store
===========

## Running locally

Default page:
* http://localhost

# Building the images

If you are testing locally on a Mac or Linux system and want to use the InMemoryStore then set the value "UseInMemoryStore": true in the appsettings.Development.json file.

docker-compose build

docker-compose -f docker-compose.yml -f docker-compose.development.yml up

---
