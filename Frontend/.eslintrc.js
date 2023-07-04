module.exports = {  
  parser: "@typescript-eslint/parser",    
  parserOptions: {
    jsx: true,
    project: ["tsconfig.json"],
    tsconfigRootDir: __dirname,
    useJSXTextNode: true,
    ecmaVersion: 2020,
  },
  extends: ["plugin:@typescript-eslint/recommended", "prettier"],  
  settings: {
    react: {
      version: "18.2.0",
    },
  },
  parserOptions: {
    ecmaVersion: 'latest',
    sourceType: 'module'
  },
  plugins: ["@typescript-eslint"],
  rules: {
  },
};

