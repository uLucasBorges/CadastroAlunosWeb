<template>


    <div>

        <div class="barraTop">
            <nav class="marginPrincipal">
                <router-link to="/professores"> Professores</router-link>
                <router-link to="/alunoss"> Alunos</router-link>
                <router-link to="/cadastrar"> Cadastrar Alunos</router-link>
            </nav>
        </div>

        <h1> Alunos </h1>
        <div>


        </div>



        <table>
            <thead>
            <th>Mat.</th>
            <th>Nome</th>
            <th>Sobrenome</th>
            <th>Opcoes</th>
            </thead>
            <!-- <tbody v-if="alunos.lenght"> -->
            <tbody>


                <tr v-for="aluno of alunos" v-bind:key="aluno">
                    <!-- <td>{{aluno.id}}</td> -->
                    <td class="colPequeno"> {{aluno.id}}</td>
                    <router-link :to="`/alunoDetalhe/${aluno.id}`" tag="td" style="cursor: pointer">
                        <td> {{aluno.nome}} </td>
                    </router-link>
                    <td> {{aluno.sobrenome}}</td>
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
        name: 'Alunos',

        data() {
            return {
                titulo: "Professor:",
                professorId: 2,
                nome: "",
                alunos: [{}],
                alunosByProf: [],
                professores: [],
                message: "",
                success: "",
                data: [{}],
                aluno: {},
                professor: {},
                professorNome: ''

            };
        },
        created() {
            this.login();
            this.get()
        },
        props: {},

        methods: {
            remover(aluno) {
                axios.delete(`http://localhost:50598/delete/${aluno.id}`)
                let indice = this.alunos.indexOf(aluno);
                this.alunos.splice(indice, 1);

            },

            get() {
                axios
                    .get('http://localhost:50598/list')
                    .then((resultado) => {
                        console.log(resultado.data)

                        this.alunos = resultado.data;
                        this.message = resultado.message;
                    })
            },

            login() {
                axios
                    .post('http://localhost:50598/login')
            },
        },
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
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