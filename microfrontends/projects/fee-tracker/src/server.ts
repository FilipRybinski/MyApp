import { initNodeFederation } from '@softarc/native-federation-node';

(async () => {

  await initNodeFederation({
    relBundlePath: '../browser/'
  });
  
  await import('./bootstrap-server');

})();
