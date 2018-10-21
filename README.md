# Senty Webhooks to mail retranslator

## Build docker image
docker build . -t sentrytomail

## Run docker SentryToMail service
You can use appsettings.json or Environment variables to set access-token, mail server, etc.

docker run --name sentrytomail --rm -d -p 8000:80 -e ASPNETCORE_ENVIRONMENT=Development -e SecuritySettings
:Token=sometoken -e SmtpOptions:Host=smtp.server.com sentrytomail