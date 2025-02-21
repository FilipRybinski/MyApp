// Please note that this is a temporary workaround for a known issue in the implementation.
// https://github.com/angular-architects/module-federation-plugin/issues/767

const fs = require('fs');
const path = require('path');

const args = process.argv.slice(2);

const appName = args[0];
if(!appName) console.error(`No app name provided!`);

const serverFilePath = path.join(__dirname, 'dist', appName, 'server', 'server.mjs');

fs.readFile(serverFilePath, 'utf8', (err, data) => {
  if (err) {
    console.error(`Error reading ${serverFilePath}:`, err);
    return;
  }

  const result = data.replace(/e\?\.(cacheTag\s?\?\s?`[^`]+`\s?:\s?"";?)/g, '(e && e.cacheTag ? `?t=${e.cacheTag}` : "")');

  fs.writeFile(serverFilePath, result, 'utf8', (err) => {
    if (err) console.error(`Error writing ${serverFilePath}:`, err);
    else console.log(`server.mjs modified successfully for ${appName}.`);
  });
});
