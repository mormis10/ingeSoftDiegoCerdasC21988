<template>
    <div class="container mt-5">
       <h1 class="display-4 text-center">Lista de países</h1>
       <table
 class="table is-bordered is-striped is-narrow is-hoverable
is-fullwidth"
 >
 <thead>
 <tr>
 <th>Nombre</th>
 <th>Continente</th>
 <th>Idioma</th>
 <th>Acciones</th>
 </tr>
 </thead>
 <tbody>
 <tr v-for="(country,index) of countries" :key="index">
     <td>{{ country.name }}</td>
     <td>{{country.continent}}</td>
     <td>{{ country.language }}</td>
 <td>
    <button class="btn btn-secondary btn-sm" v-on:click="editCountry(index)">Editar</button>
 <button class="btn btn-danger btn-sm" v-on:click="deleteCountry(index)">Eliminar</button>
 </td>
 </tr>
 </tbody>
 </table>
 </div>
</template>

<script>
    import axios from "axios"
    export default {
        name: "CountriesList",
        data() {
        return {
    countries: [
      { name: "Costa Rica", continent: "América", language: "Español" },
      { name: "Japón", continent: "Asia", language: "Japonés" },
      { name: "Corea del Sur", continent: "Asia", language: "Coreano" },
      { name: "Italia", continent: "Europa", language: "Italiano" },
      { name: "Alemania", continent: "Europa", language: "Alemán" },
    ],
  };
},

methods:{
    deleteCountry(index){
        // tengo que recordar que este método es el índice que voy a eliminar y el count
        this.countries.splice(index,1);
    },
    editCountry(index){
        const new_name = prompt("Ingrese un nuevo nombre para este país: ",this.countries[index].name);
        if(new_name && new_name.trim() != ""){
            this.countries.splice(index,1,{...this.countries[index],name: new_name})
        }
    },
    getCountries(){
        axios.get("https://localhost:7019/api/country").then((response) =>{
            this.countries = response.data;

        });
        
    },
    created: function () {
     this.getCountries();
    },
    
}

}
</script>

<style lang="scss" scoped>

</style>