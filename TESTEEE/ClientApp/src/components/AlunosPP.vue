<template>


    <div>
        <h1> {{titulo}} {{name}} </h1>
        <div>


        </div>



        <table>
            <thead>
            <th>Mat.</th>
            <th>Nome</th>
            <th>Sobrenome</th>
            <th>Opções</th>
            </thead>

            <tbody>


                <!-- <td>{{aluno.id}}</td> -->
                <tr v-for="aluno of alunos" v-bind:key="aluno">
                    <td class="colPequeno"> {{aluno.id}} </td>
                    <router-link :to="`/alunoDetalhe/${aluno.id}`" tag="td" style="cursor: pointer">
                        <td> {{aluno.nome}}  </td>
                    </router-link>
                    <td> {{aluno.sobrenome}} </td>
                    <td class="colPequeno">
                        <button class="btn btn_Danger" @click="remover(aluno)"> Remover </button>
                    </td>
                </tr>

            </tbody>
        </table>

        <!--<div class="not" v-if="alunos.length === 0 && !this.professorId || alunosByProf.length === 0 && this.professorId">
            <br>
            <h1>
                Alunos não encontrados!
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
                alunos: [{}],
                aluno: {},
                professorId: 2,
                name : ''


            };
        },
        created() {
            this.get()
            this.getALunos();
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
                        console.log(resultado.nome)

                        this.name = resultado.data.nome;
                    })
            }, 


            getALunos() {
                axios
                    .get(`https://localhost:7038/api/alunos/by/professor/${this.professorId}`)
                    .then((resultado) => {
                        console.log(resultado)

                        this.alunos = resultado.data;
                        this.message = resultado.message;
                    })
            }, 

            getBy(id) {
                axios
                    .get(`https://localhost:7038/api/alunos/search/${id}`)
                    .then(resultado => {
                        // console.log(JSON.stringify(alunos))
                        this.aluno = resultado.data;
                        this.message = resultado.message;
                    })
            }


        },
    }

 
</script>

<style scoped>

    Input {
        width: calc(100% - 195px);
        border: 0;
        padding: 20px;
        font-size: 1.3em;
        color: #687f7f;
        display: inline;
    }

    .not {
        font-size: 1.3em;
        display: inline;
        background-color: rgb(238, 15, 15);
    }

    .btnInput {
        width: 150px;
        border: 0px;
        padding: 20px;
        font-size: 1.3em;
        display: inline;
        background-color: rgb(116, 115, 115);
    }

        .btnInput:hover {
            width: 150px;
            padding: 20px;
            margin: 0px;
            border: 0;
        }
</style>