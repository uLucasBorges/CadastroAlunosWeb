<template>

    <div>
        
        <div class="barraTop">
            <nav class="marginPrincipal">
                <router-link to="/professores"> Professores</router-link>
                <router-link to="/alunoss"> Alunos</router-link>
                <router-link to="/cadastrar"> Cadastrar Alunos</router-link>
            </nav>
        </div>

        <h1> Professores </h1>
        <table>
            <thead>
            <th>Cod.</th>
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
                                 style="cursor:pointer"> <td> {{professor.nome}} </td></router-link>

                    

                    <td td class="colPequeno">
                        <router-link v-bind:to="`/alunos/${professor.id}`"
                                     tag="td"
                                     style="cursor:pointer">{{professor.alunos}}</router-link>
                    </td>
                </tr>
            </tbody>
            <!-- <tfoot>
          n�o existem alunos encotrados.
        </tfoot> -->
        </table>


        <!--<br>
    <div v-if="Professores.length === 0">
        <h1>
            Professores n�o encontrados!
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
            this.getName(this.professorId);
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
            },

            getName(id) {
                axios
                    .get(`https://localhost:7038/api/professor/${id}`)
                    .then((resultado) => {
                        console.log(resultado)
                        this.name = resultado.data.nome;
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