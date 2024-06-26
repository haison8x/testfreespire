FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS builder

WORKDIR /src

COPY ./Test/Test.csproj ./Test/Test.csproj


WORKDIR /src/Test
RUN dotnet restore -v diag

COPY ./Test .
RUN dotnet  publish -c Release -r linux-x64 -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base

WORKDIR /app
COPY --from=builder /app .

ENV TZ="America/La_Paz" 

RUN apk update && apk add nano 
RUN apk --no-cache add msttcorefonts-installer fontconfig && \
    update-ms-fonts && \
    fc-cache -f
RUN apk --no-cache add icu-libs libc6-compat


ENTRYPOINT ["dotnet", "Test.dll"]