const path = require('path');
const webpack = require('webpack');
const CopyWebpackPlugin = require('copy-webpack-plugin');

const Assets = require('./webpack.assets');

module.exports = {
  entry: {
    app: './wwwroot/js/site.js',
  },
  output: {
    path: __dirname + '/wwwroot/',
    filename: '[name].bundle.js'
  },
  plugins: [
    new CopyWebpackPlugin(
      Assets.map(asset => {
        return {
          from: path.resolve(__dirname, `./node_modules/${asset}`),
          to: path.resolve(__dirname, `./wwwroot/lib/${asset}`)
        };
      })
    )
  ]
};
