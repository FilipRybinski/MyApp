#build stage
FROM node:lts-alpine as build
WORKDIR /app
COPY ./src/ClientApp/MyApp ./
RUN npm install
RUN npm install -g @angular/cli@latest
RUN ng build 


# production stage
FROM nginx:stable-alpine as production
COPY --from=build ./dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]