# Alpine failing at the moment of writing
FROM node:latest
WORKDIR /app
COPY . .
RUN npm ci --omit=dev
RUN npm run build
ENV NODE_ENV production
EXPOSE 3000
CMD [ "node", "server.js" ]