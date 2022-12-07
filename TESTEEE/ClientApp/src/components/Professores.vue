<template>

    <div>
        <h1> {{titulo}} </h1>
        <table>
            <thead>
            <th>Cód.</th>
            <th>Nome</th>
            <th>Alunos</th>
            </thead>
            <!-- <tbody v-if="alunos.lenght"> -->
            <tbody>
                <tr v-for="professor of professores" v-bind:key="professor">
                    <!-- <td>{{aluno.id}}</td> -->
                    <td class="colPequeno"> {{professor.id}}</td>

                    <router-link v-bind:to="`/alunos/${professor.id}`"
                                 tag="td"
                                 style="cursor:pointer">{{professor.nome}}</router-link>

                    <td td class="colPequeno">
                        <router-link v-bind:to="`/alunos/${professor.id}`"
                                     tag="td"
                                     style="cursor:pointer">{{professor.alunos}}</router-link>
                    </td>
                </tr>
            </tbody>
            <!-- <tfoot>
              não existem alunos encotrados.
            </tfoot> -->
        </table>


        <!--<br>
        <div v-if="Professores.length === 0">
            <h1>
                Professores não encontrados!
            </h1>
        </div>-->



    </div>

</template>

<script>
 import axios from 'axios'

    export default {

        components: {

        },
        name: 'ALunos',

        data() {
            return {
                titulo: "Professor:",
                professores: [{}],
           

            };
        },
        created() {
                this.get()
        },
        props: {},

        methods: {
            get() {
                axios
                    .get('https://localhost:7038/api/professores/list')
                    .then((resultado) => {
                        console.log(resultado)

                        this.professores = resultado.data;
                        this.message = resultado.message;
                    })
            }
        },
    }
</script>


<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

    .colPequeno {
        text-align: center;
        width: 15%;
    }

</style>