<?php
include 'header.php';
try {
    $conn = mysqli_connect($servidor, $usuario, $password, $baseDatos);

    if (!$conn) {
        echo '{"codigo": 400, "mensaje": "CONEXION FALLO", "respuesta": ""}';
    } else {
        echo '{"codigo": 200, "mensaje": "CONECTADO CORRECTAMENTE", "respuesta": ""}';
    }
} catch (\Throwable $th) {
    echo '{"codigo": 400, "mensaje": "ERROR, NO SE PUEDE ESTABLECER LA CONEXION", "respuesta": ""}';
}