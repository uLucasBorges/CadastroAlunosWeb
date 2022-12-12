<template>
    <div>

            
            <h1>Volte Sempre.</h1>



            <main class="container">


                <h2>Login</h2>
                <form>
                    <div class="input-field">
                        <input type="text" name="username" id="username"
                               placeholder="Enter Your Username" required v-model="username">
                        <div class="underline"></div>
                    </div>



                    <div class="input-field">
                        <input type="password" name="password" id="password"
                               placeholder="Enter Your Password" required v-model="password">
                        <div class="underline"></div>
                    </div>


                </form>


                <button type="submit" @click="login()"> confirm </button>


            </main>



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
                username: '',
                email: '',
                password: '',
                autenticado: false

            };
        },
        created() {
    
        },
        props: {},
        methods: {
            login() {
                let dados = {
                    name: this.username,
                    email: this.username + '@clear.sale',
                    password: this.password,
                    confirmPassword: this.password
                }

                axios.post(`http://localhost:50598/Log`, dados)

             
                    this.$router.push('/alunoss');
                

                
            },           
        },
    }
</script>

<style scoped>

    @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@100;200;300;400;500;600;700&display=swap');

    * {
        margin: 0;
        border: 0;
        padding: 0;
        box-sizing: border-box;
        font-family: "Poppins", sans-serif;
    }

    body {
        background: linear-gradient(45deg, #8e2de2, #4a00e0);
        background-repeat: no-repeat;
        min-height: 100vh;
        min-width: 100vw;
        display: flex;
        align-items: center;
        justify-content: center;
    }

    main.container {
        background: white;
        min-width: 320px;
        min-height: 40vh;
        padding: 2rem;
        box-shadow: 5px 5px 15px rgba(0, 0, 0, 0.2);
        border-radius: 8px;
    }

    main h2 {
        font-weight: 600;
        margin-bottom: 2rem;
        position: relative;
    }
    
    h1 {
        font-weight: 600;
        margin-bottom: 2rem;
        position: relative;
    }

    main h2::before {
        content: '';
        position: absolute;
        height: 4px;
        width: 25px;
        bottom: 3px;
        left: 0;
        border-radius: 8px;
        background: linear-gradient(45deg, #8e2de2, #4a00e0);
    }
         h1::before {
            content: '';
            position: absolute;
            height: 4px;
            width: 20px;
            bottom: 3px;
            left: 0;
            border-radius: 8px;
            background: linear-gradient(45deg, #8e2de2, #4a00e0);
        }

    form {
        display: flex;
        flex-direction: column;
    }


        button:hover {
            background-color: deepskyblue;
            cursor: pointer;
        }


    .input-field {
        position: relative;
    }

    form .input-field:first-child {
        margin-bottom: 1.5rem;
    }

    .input-field .underline::before {
        content: '';
        position: absolute;
        height: 4px;
        width: 75%;
        bottom: -2px;
        left: 0;
        background: rgba(0, 0, 0, 0.2);
    }

    .input-field .underline::after {
        content: '';
        position: absolute;
        height: 2px;
        width: 80%;
        bottom: -5px;
        left: 0;
        background: linear-gradient(45deg, #8e2de2, #4a00e0);
        transform: scaleX(0);
        transition: all .3s ease-in-out;
        transform-origin: left;
    }

    .input-field input:focus ~ .underline::after {
        transform: scaleX(1);
    }

    .input-field input {
        outline: none;
        font-size: 0.9rem;
        color: rgba(0, 0, 0, 0.7);
        width: 80%;
    }

        .input-field input::placeholder {
            color: rgba(0, 0, 0, 0.5);
        }

     button {
        margin-top: 2rem;
        padding: 0.4rem;
        width: 100%;
        background: linear-gradient(to left, #4776E6, #8e54e9);
        cursor: pointer;
        color: white;
        font-size: 0.9rem;
        font-weight: 300;
        border-radius: 4px;
        transition: all 0.3s ease;
    }

        button:hover {
            letter-spacing: 0.5px;
            background: linear-gradient(to right, #4776E6, #8e54e9);
        }

    .footer {
        display: flex;
        flex-direction: column;
        margin-top: 1rem;
    }

        .footer span {
            color: rgba(0, 0, 0, 0.7);
            font-size: 0.8rem;
            text-align: center;
        }

        .footer .social-field {
            padding: 0.4rem;
            border-radius: 4px;
            font-size: 0.85rem;
            width: 100%;
            cursor: pointer;
            margin-top: 1rem;
        }

            .footer .social-field a i {
                margin: 0 0.5rem;
                width: 15px;
            }

            .footer .social-field a {
                text-decoration: none;
                color: white;
            }

            .footer .social-field.twitter {
                background: linear-gradient(to right, #56a7f2, #468aca);
            }

            .footer .social-field.facebook {
                background: linear-gradient(to right, #1e3c72, #2a5298);
            }


    .form-header {
        margin-bottom: 3rem;
        display: flex;
        justify-content: space-between;
    }

    .gender-title h6 {
        font-size: 0.75rem;
        font-weight: 600;
        color: #000000c0;
    }
</style>