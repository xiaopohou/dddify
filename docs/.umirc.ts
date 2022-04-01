import { defineConfig } from 'dumi';

export default defineConfig({
  title: 'Dddify',
  mode: 'site',
  base: '/',
  publicPath: './',
  history: { 
    type: 'hash' 
  },
  ignoreMomentLocale: true,
  // more config: https://d.umijs.org/config
});
