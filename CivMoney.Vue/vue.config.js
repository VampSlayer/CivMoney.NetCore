module.exports = {
  outputDir: "../CivMoney/wwwroot",
  devServer: {
    proxy: {
      "/api/*": {
        target: "http://localhost:54574/"
      }
    }
  },
  pages: {
    index: {
      entry: "src/main.js",
      template: "src/public/index.html",
      filename: "index.html"
    }
  }
};
