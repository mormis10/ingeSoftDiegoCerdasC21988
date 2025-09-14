import { createApp } from 'vue'
import App from './App.vue'
import { createRouter, createWebHistory } from "vue-router";
import CountriesList from "./CountriesList.vue";
import CountryForm from "./CountryForm.vue";

const router = createRouter({
    history: createWebHistory(),
    routes: [
        { path: "/", name: "Home", component: CountriesList },
        { path: "/country", name: "Country", component: CountryForm},
    ],

});

createApp(App).use(router).mount('#app')
