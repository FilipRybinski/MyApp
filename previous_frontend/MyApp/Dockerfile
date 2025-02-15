FROM node:lts-alpine as build
RUN apk add chromium
WORKDIR /app

ENV CHROME_BIN=/usr/bin/chromium-browser

COPY ./previous_frontend/MyApp ./

RUN npm install
RUN npm install -g @angular/cli@latest
RUN ng test --watch=false
RUN ng build --configuration=production

FROM node:lts-alpine as srr
WORKDIR /app

COPY --from=build /app/dist /app/dist
COPY ./previous_frontend/MyApp/package.json ./

RUN npm install --only=production

EXPOSE 4000

CMD ["node", "dist/my-app/server/server.mjs"]
