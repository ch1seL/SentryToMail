# Senty Webhooks to mail retranslator
Resolving the issue of splitting errors of different environments in accordance with Email Addresses.

It receive Sentry's Webhook and send it to email string.Format(MailOptions:MailToTemplate, Environment)

## Build docker image
docker build . -t sentrytomail

## Run docker SentryToMail service
You can use appsettings.json or Environment variables to set access-token, mail server, etc.

docker run --name sentrytomail --rm -d -p 8000:80 -e ASPNETCORE_ENVIRONMENT=Staging -e SecuritySettings
:Token=sometoken -e SmtpOptions:Host=smtp.server.com -e MailOptions:MailFromTemplate=errors-{0}@you-mail.com -e MailOptions:MailToTemplate=errors-{0}@you-mail.com sentrytomail 

## Run in docker-compose
version: '3.3'
services:
  sentrytomail:
    environment:
       TZ: "Europe/Moscow"
       ASPNETCORE_ENVIRONMENT: "Production"
       SecurityOptions:Token: "sentry to mail access token"
       SmtpOptions:Host: "you-mail-server.com"
       MailOptions:MailFromTemplate: "{0}@you-mail.com"
       MailOptions:MailToTemplate: "errors-{0}@you-mail.com"
       Sentry:Dsn: "you sentry dsn key"
    container_name: sentrytomail
    image: sentrytomail:latest
    restart: always
    ports:
      - "8000:80"
    volumes:
      - ./Repositories:/app/Repositories
