## Getting started

Before you start, make sure you have a recent version of [NodeJS](http://nodejs.org/) environment *>=6.0* with NPM 3.

From the project folder, execute the following commands:

```
npm install
```

This will install all required dependencies, including a local version of Webpack that is going to
build and bundle the app. There is no need to install Webpack globally. 

To run the app execute the following command:

```shell
npm start
```

## Bundling

To build an optimized, minified production bundle (output to /dist) execute:

- Install @angular/cli

```
npm install -g @angular/cli
```

- Build to dist folder

```
ng build --prod
```

## Deploy to Azure

- Link (https://www.aspnetzero.com/Documents/Step-by-step-publish-to-azure-angular)
