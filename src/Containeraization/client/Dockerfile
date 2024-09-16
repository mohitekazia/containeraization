FROM node:alpine

WORKDIR /app

RUN npm install -g @angular/cli@18

COPY ["package*.json","./"]

RUN npm install
RUN npm update
COPY . .
WORKDIR /app/client

CMD ["ng", "serve", "--host", "0.0.0.0", "--port","4200"]


