<template>
    <div>

        <div class="barraTop">
            <nav class="marginPrincipal">
                <router-link to="/professores"> Professores</router-link>
                <router-link to="/alunoss"> Alunos</router-link>
                <router-link to="/cadastrar"> Cadastrar Alunos</router-link>
            </nav>
        </div>

        <div style="display: flex; width: 50%">
            <h1>
                Codigo de aluno: {{aluno.id}}
            </h1>

            <div class="voltar">
                <button class="btn btnVoltar" @click="voltar()">Voltar</button>
                <button class="btn btnEditar" @click="edita()" v-if="!visualizando">Editar</button>
            </div>
        </div>

        <table>
            <tbody>
                <tr>
                    <td class="colPequeno">Matricula: </td>
                    <td>
                        <label>{{aluno.id}}</label>
                    </td>
                </tr>
                <tr>
                    <td class="colPequeno">Nome: </td>
                    <td>
                        <label v-if="!visualizando">{{aluno.nome}}</label>
                        <input v-else v-model="aluno.nome" type="text" />
                    </td>
                </tr>
                <tr>
                    <td class="colPequeno">Sobrenome: </td>
                    <td>
                        <label v-if="!visualizando">{{aluno.sobrenome}}</label>
                        <input v-else v-model="aluno.sobrenome" type="text" />
                    </td>
                </tr>
                <tr>
                    <td class="colPequeno">Data Nascimento: </td>
                    <td>
                        <label v-if="!visualizando">{{aluno.nome}}</label>
                        <input v-else v-model="aluno.dataNascimento" type="text" />
                    </td>
                </tr>
                <tr>
                    <td class="colPequeno">Professor: </td>
                    <td>
                        <label v-if="!visualizando">{{aluno.professorNome}}</label>
                        <select v-model="aluno.professorNome" v-else>
                            <option v-for="(professor,  index) in professores" :key="index" v-bind:value="professor">
                                {{professor.nome}}
                            </option>
                        </select>
                    </td>
                </tr>

            </tbody>
        </table>

        <button class="btn btnConfirmar" @click="editar(aluno)" v-if="visualizando">Salvar</button>
        <button class="btn btnCancelar" @click="cancelar()" v-if="visualizando">Cancelar</button>

    </div>
</template>

<script>

    import axios from 'axios'

    export default {
        data() {
            return {
                aluno: {},
                id: this.$route.params.id,
                professores: [{}],
                visualizando: false
            }
        }, created() {

            axios
                .get(`http://localhost:50598/ById/${this.id}`)
                .then(resultado => {
                    console.log(resultado.data)
                    this.aluno = resultado.data
                })
               

        }


        ,
        methods: {
            voltar() {
                this.$router.back();
            },

            editar(aluno) {

                axios.put(`http://localhost:50598/update/${aluno.id}`, aluno)

                this.visualizando = !this.visualizando;
            },

            edita() {
                this.visualizando = true;
            },

            cancelar() {
                this.visualizando = false;
            }
        }
    };

</script>

<style scoped>

    .colPequeno {
        width: 20%;
    }

    input, select {
        margin: 0;
        padding: 5px,10px;
        font-size: 0.9em;
        border: 1px solid silver;
        border-radius: 5px;
        font-family: Montserrat;
        width: 95%;
        background-color: rgb(245,245,245);
    }

    select {
        height: 38px;
        width: 100%;
    }

    .voltar {
        width: 50%;
        position: absolute;
        margin-top: 15px;
    }

    .btnVoltar {
        float: right;
        background-color: rgb(199,199,199);
    }

    .btnEditar {
        float: right;
        background-color: rgb(76,186,249);
    }

    .btnConfirmar {
        float: right;
        background-color: rgb(79, 196, 68);
    }

    .btnCancelar {
        float: right;
        background-color: rgb(249,186,92);
    }
</style>