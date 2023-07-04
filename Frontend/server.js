"use strict";

//TODO: Use or remove server/server.ts
// TODO: Set up the package.json script properly for development
const path = require("path");
const express = require("express");
const { createProxyMiddleware } = require("http-proxy-middleware");

const PORT = 3000;
const HOST = "0.0.0.0";

const app = express();
app.use(
  "/api",
  createProxyMiddleware({
    target: `http://${process.env.backend_host ?? "localhost:5000"}`,
    changeOrigin: true,
    // We don't need the /api part in the target url
    pathRewrite: { "^/api": "" },
    ws: true,
  }),
);
app.use(express.static(path.join(__dirname, "build")));
app.use(express.static("public"));
app.listen(PORT, HOST, () => {
  console.log(`Running on http://${HOST}:${PORT}`);
});
