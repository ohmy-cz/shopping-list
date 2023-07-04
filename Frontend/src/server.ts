"use strict";

import path from "path";
import express from "express";
import { createProxyMiddleware } from "http-proxy-middleware";

const PORT = 3000;
const HOST = "0.0.0.0";

const app = express();
app.use(
  "/api",
  createProxyMiddleware({
    target: "http://localhost:666",
    pathRewrite: { "^/api": "" },
    changeOrigin: true,
    ws: true,
  }),
);
app.use(express.static(path.join(__dirname, "build")));
app.use(express.static("public"));
app.listen(PORT, HOST, () => {
  console.log(`Running on http://${HOST}:${PORT}`);
});
