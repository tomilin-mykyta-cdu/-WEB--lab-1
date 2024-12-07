FROM node:20.12.0

WORKDIR /app

COPY package*.json ./

COPY . ./

RUN npm i

EXPOSE 3000

CMD ["node", "app.js"]