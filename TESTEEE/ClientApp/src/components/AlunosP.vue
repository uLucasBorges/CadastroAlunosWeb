<template>


    <div>
        <h1> Professor: {{professorNome}}</h1>
        <div>


        </div>


        <table>
            <thead>
            <th>Mat.</th>
            <th>Nome</th>
            <th>Sobrenome</th>
            <th>Opções</th>
            </thead>
            <!-- <tbody v-if="alunos.lenght"> -->
            <tbody>


                <tr v-for="alunoProf of alunosByProf" v-bind:key="alunoProf">
                    <!-- <td>{{alunoProf.id}}</td> -->
                    <td class="colPequeno"> {{alunoProf.id}}</td>
                    <router-link :to="`/alunoDetalhe/${alunoProf.id}`" tag="td" style="cursor: pointer">
                        {{alunoProf.nome }}
                    </router-link>
                    <td> {{alunoProf.sobrenome}}</td>
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
        name: 'Alunoss                                                                                                                                          ',

        data() {
            return {
                titulo: "Professor:",
                professorId: this.$route.params.prof_id,
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
                this.getProfessores();
                this.alunosProf(this.professorId);
                this.getProfessorById(this.professorId);
                this.get()
        },
        props: {},

        methods: {
        
            alunosProf(Professorid) {
                axios
                    .get(`https://localhost:7038/api/alunos/by/professor/${Professorid}`, Professorid)
                    .then(resultado => {
                        this.alunosByProf = resultado.data;
                    })


            },

            remover(aluno) {
                axios.delete(`https://localhost:7038/api/delete/aluno/${aluno.id}`)
                let indice = this.alunos.indexOf(aluno);
                this.alunos.splice(indice, 1);

            },
            
            , getProfessorById(id) {
                axios
                    .get(`https://localhost:7038/api/professor/${id}`, id)
                    .then(resultado => {
                        this.professorNome = resultado.data;

                    })
            },

            getProfessores() {
                axios
                    .get(`https://localhost:7038/api/professores/list`)
                    .then(resultado => {
                        // console.log(JSON.stringify(alunos))
                        this.professor = resultado.data.data;
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
            padding: 20x;
            margin: 0px;
            border: 0;
        }

</style>