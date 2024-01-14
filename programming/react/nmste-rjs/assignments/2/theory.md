# Assignment 2 : Igniting our App 🚀

* **What is NPM**
  * NPM is a package manager which has all the node packages.
  * It is the default package manager for js's runtime node.
<br/>

* **What is parcel?**
  * Parcel is bundler for javascript application which provides us many extra features like:
    * **Hot Module Reload** : When we make a page change then automatically page reloads in browser. This is done via file watching algorithm written in C++;
    * **Tree Shaking(Production Optimization)**: It statically analyzes the imports and exports of each module, and removes everything that isn't used. For both **ES Modules** & **CommonJS**
    * **Dev Server**: Out of box dev server `npx parcel index.html`
    * **HTTPs Support**
    * **Minification**
    * **Diagnostic**: Beatification of error made in our projects and are clearly displayed in console
    * **Multi Core**: Parcel can utilize multiple core to parallelize the tasks. 
    * **Caching**: Everything Parcel does is cached – transformation, dependency resolution, bundling, optimizing, and everything in between. This means the dev server restarts instantly, and the same code is never built twice.
    * **Lazy Dev Builds**: Parcel can defer builds of file unless they are requested in browser. 
    * **Image Optimization**
    * **Compression**: Compress your app before you deploy using Gzip and Brotli.
    * **Code Splitting**: When multiple parts of your application depend on the same common modules, they are automatically deduplicated into a separate bundle. This allows commonly used dependencies to be loaded in parallel with your application code and cached separately by the browser
    * **Content hashing**: Parcel automatically includes content hashes in the names of all output files. This enables long-term browser caching, because the output is guaranteed not to change unless the name does.
    * **Transpilation**: Parcel transpiles your JavaScript and CSS for your target browsers automatically! Just declare a `browserslist` in your package.json, and Parcel takes care of transpiling only what's needed.

> A polyfill will try to emulate certain APIs, so can use them as if they were already implemented.
> A transpiler on the other hand will transform your code and replace the respective code section by other code, which can already be executed

<br/>

* **What is .parcel-cache?**
  * It is where parcel caches the build files for faster re builds in development environment.

* **NPX - Node Package Execute(NPM Package Runner)**
  * We use npx when we want to execute any npm package
<br/>

* **What is difference between dependencies & devDependencies?**
  * dependencies are those packages which we need in all environments
  * devDependencies are only specific packages which we need only in development environment . Like parcel is a dev dependency. 
<br/>

* **What is the difference between package and package-lock.json**
  * Package.json: Contains the approximate version of the dependencies our project has
  * Package-lock.json: Contains the exact version number of dependencies our project is using. 
<br/>

* **Why we should not modify package-lock.json?**
  * Because it consists of exact version number being used and also version of transitive dependencies being used. 
  * If we want to have reliability in running our app on different dev machines and prod server we should not modify this file. 
<br/>

* **What is browserslist**
  * It is a package which consists of configuration about which browsers our code should support. 
<br/>

* **What is ^ & ~**
  * ^ Caret will automatically upgrade the app to next minor version
  * ~ Tilde will automatically upgrade the app to next major version. Hence it should be used with caution. 
<br/>

