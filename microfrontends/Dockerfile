FROM nginx:stable-alpine as nginx

ARG CERTIFICATE_CONTENT
ARG PRIVATE_KEY_CONTENT

RUN echo "$CERTIFICATE_CONTENT" > /etc/ssl/certs/nginx.crt
RUN echo "$PRIVATE_KEY_CONTENT" > /etc/ssl/private/nginx.key

COPY config/nginx.conf /etc/nginx/nginx.conf

EXPOSE 80
EXPOSE 443

CMD ["nginx", "-g", "daemon off;"]