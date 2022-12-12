<template>
  <nav-menu></nav-menu>
  <router-view />
</template>

<script>


export default {
  name: 'App',
  components: {
      
  }
}
</script>

<style>
    @import url("https://fonts.googleapis.com/css?family=Montserrat:400,700");

    body {
        background-color: #eee;
        font-family: "Montserrat", sans-serif;
        display: grid;
        justify-items: center;
    }

    body, html {
        margin: 0;
        height: 100%;
    }

    .marginPrincipal {
        margin: auto;
    }

    #app {
        width: 50%;
    }

    table {
        margin: 0px;
        padding: 0px;
        list-style-type: none;
        width: 100%;
        background-color: #e0edf4;
    }

        table tr td {
            padding: 20px;
            font-size: 1.3em;
            background-color: #e0edf4;
            margin-bottom: 2px;
            color: #3e5252;
        }

        table thead th {
            background-color: rgb(184, 208, 216);
            font-size: 1.2em;
            padding: 10px 0px;
            text-align: center !important;
        }

    .colPequeno {
        width: 5%;
        text-align: right;
        background-color: rgb(125,217,245);
        font-weight: bold;

    }

    .btn_Danger {
        background-color: #fa4430;
    }

    .btn {
        padding: 10px 20px;
        cursor: pointer;
        border: 1px solid #000;
        color: white;
        font-weight: bold;
        border-radius: 5px;
        border-bottom: 3px solid black;
    }

        .btn:hover {
            text-shadow: 1px 1px 1px black;
            margin-top: 3px;
            border-bottom: 1px solid black;
        }




    .barraTop {
        background-color: rgb(230,230,230);
    }

    .marginPrincipal {
    }


    nav {
        padding: 20px 20px 20px 0px;
    }

        nav a {
            padding: 10px;
            text-decoration: none;
            background-color: #fff;
            border-radius: 3px;
            color: rgb(0,110,255);
            font-weight: bold;
            margin-right: 15px;
        }

        nav .router-link-active {
            background-color: rgb(230,230,230);
            color: black;
        }
</style>
