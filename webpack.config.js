const path = require("path");

module.exports = {
    entry: "./wwwroot/scripts/main.ts",
    output: {
        path: path.resolve(__dirname, "wwwroot/scripts"),
        filename: "main.js",
        publicPath: "/scripts"
    },
    resolve: {
        extensions: [".js", ".ts"]
    },
    module: {
        rules: [
            {
                test: /\.ts$/,
                use: "ts-loader"
            }
        ]
    },
    plugins: [ ]
};
