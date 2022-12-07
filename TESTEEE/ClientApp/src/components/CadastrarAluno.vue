<template>
    <div>


        <div>

            <form action="#">
                <div class="form-header">
                    <div class="title">
                        <br>
                        <h1>Cadastre-se</h1>
                    </div>

                </div>

                <div class="input-group">
                    <div class="input-box">
                        <label for="firstname">Primeiro Nome</label>
                        <input id="firstname" type="text" name="firstname" placeholder="Digite seu primeiro nome" required v-model="nome">
                    </div>

                    <div class="input-box">
                        <label for="lastname">Sobrenome</label>
                        <input id="lastname" type="text" name="lastname" placeholder="Digite seu sobrenome" required v-model="sobrenome">
                    </div>

                    <div class="input-box">
                        <label for="email">Data de Nascimento</label>
                        <input id="email" type="email" name="email" placeholder="Digite sua data de nascimento" required v-model="dataNascimento">
                    </div>



                    <div class="input-box">
                        <label for="number">Celular</label>
                        <input id="number" type="tel" name="number" placeholder="(xx) xxxx-xxxx" required v-model="telefone">
                    </div>

                </div>

                <div class="continue-button">
                    <button @click="addAluno()" v-if="nome.length >= 1"> Confirmar </button>
                </div>


            </form>

        </div>

    </div>
</template>

<script>

import axios from 'axios'


export default {
  components: {

  },
  name: 'ALunos',
  data(){
    return {
      titulo: "Professor:",
      professorId: this.$route.params.prof_id,
      nome: "",
      alunos: [],
      alunosByProf:[],
      professores: [],
      message: "",
      success: "",
      data : [{}],
      aluno : {},
      professor : {},
      professorNome : ''

    };
  },
created(){
  if(this.professorId){
 this.getProfessores();
 this.alunosProf(this.professorId);
 this.getProfessorById(this.professorId);
  } else{
 this.get()
  }
  },
  props: {},
  methods: {
     addAluno(){
      let _aluno = {
        id: this.id,
        nome : this.nome,
        sobrenome: this.sobrenome,
        professor: {
          id: this.professor.Id,
          nome: this.professor.nome,
          materia: this.professor.materia
        }
      }

     axios.post(`https://localhost:7038/api/alunos/create` , _aluno).then(res => res.json())

      this.alunos.push(_aluno);
      this.nome = '';
     },


    alunosProf(Professorid){
      axios.get(`https://localhost:7038/api/alunos/by/professor/${Professorid}` , Professorid)
      .then(resultado => {
        this.alunosByProf = resultado.data;
  })


    },

     remover(aluno){
         axios.delete(`https://localhost:7038/api/delete/aluno/${aluno.id}`).then(res => res.json())
         let indice = this.alunos.indexOf(aluno);
         this.alunos.splice(indice , 1);

     },
     get(){
         axios.get('https://localhost:7038/api/alunos/list')
      .then(resultado => {
  // console.log(JSON.stringify(alunos))
        this.alunos = resultado.data;
        this.message = resultado.message;
  })
     }, getProfessorById(id){
       axios.get(`https://localhost:7038/api/professor/${id}` , id)
      .then(resultado => {
        this.professorNome = resultado.data.nomeProfessor;

  })
     },

      getProfessores(id) {
          axios.get(`https://localhost:7038/api/professor/detalhes/${id}`)
      .then(resultado => {
  // console.log(JSON.stringify(alunos))
        this.professor = resultado.data;
        this.message = resultado.message;
  })
     },
        getBy(id){
      axios.get(`https://localhost:7038/api/alunos/search/${id}`)
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

    @import url('https://fonts.googleapis.com/css2?family=Inter:wght@200;300;400;500&family=Open+Sans:wght@300;400;500;600&display=swap');

    * {
        padding: 0;
        margin: 0;
        box-sizing: border-box;
        font-family: 'Inter', sans-serif;
    }

    body {
        width: 100%;
        height: 100vh;
        display: flex;
        justify-content: center;
        align-items: center;
        background: #0c0ce94d;
    }

    .container {
        width: 80%;
        height: 80vh;
        display: flex;
        box-shadow: 5px 5px 10px rgba(0, 0, 0, 0.212);
    }

    .form-image {
        width: 50%;
        display: flex;
        justify-content: center;
        align-items: center;
        background-color: #fde3a7d7;
        padding: 1rem;
    }

        .form-image img {
            width: 31rem;
        }

    .form {
        width: 50%;
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
        background-color: #fff;
        padding: 3rem;
    }

    .form-header {
        margin-bottom: 3rem;
        display: flex;
        justify-content: space-between;
    }

    .login-button {
        display: flex;
        align-items: center;
    }

        .login-button button {
            border: none;
            background-color: #6c63ff;
            padding: 0.4rem 1rem;
            border-radius: 5px;
            cursor: pointer;
        }

            .login-button button:hover {
                background-color: #6b63fff1;
            }

            .login-button button a {
                text-decoration: none;
                font-weight: 500;
                color: #fff;
            }

    .form-header h1::after {
        content: '';
        display: block;
        width: 5rem;
        height: 0.3rem;
        background-color: #6c63ff;
        margin: 0 auto;
        position: absolute;
        border-radius: 10px;
    }

    .input-group {
        display: flex;
        flex-wrap: wrap;
        justify-content: space-between;
        padding: 1rem 0;
    }

    .input-box {
        display: flex;
        flex-direction: column;
        margin-bottom: 1.1rem;
    }

        .input-box input {
            margin: 0.6rem 0;
            padding: 0.8rem 1.2rem;
            border: none;
            border-radius: 10px;
            box-shadow: 1px 1px 6px #0000001c;
            font-size: 0.8rem;
        }

            .input-box input:hover {
                background-color: #eeeeee75;
            }

            .input-box input:focus-visible {
                outline: 1px solid #6c63ff;
            }

        .input-box label,
        .gender-title h6 {
            font-size: 0.75rem;
            font-weight: 600;
            color: #000000c0;
        }

        .input-box input::placeholder {
            color: #000000be;
        }

    .gender-group {
        display: flex;
        justify-content: space-between;
        margin-top: 0.62rem;
        padding: 0 .5rem;
    }

    .gender-input {
        display: flex;
        align-items: center;
    }

        .gender-input input {
            margin-right: 0.35rem;
        }

        .gender-input label {
            font-size: 0.81rem;
            font-weight: 600;
            color: #000000c0;
        }

    .continue-button button {
        width: 100%;
        margin-top: 2.5rem;
        border: none;
        background-color: #6c63ff;
        padding: 0.62rem;
        border-radius: 5px;
        cursor: pointer;
    }

        .continue-button button:hover {
            background-color: #6b63fff1;
        }

        .continue-button button a {
            text-decoration: none;
            font-size: 0.93rem;
            font-weight: 500;
            color: #fff;
        }
</style>
