<?php
include 'header.php';
try {
    $conn = mysqli_connect($servidor, $usuario, $password, $baseDatos);

    if (!$conn) {
        echo '{"codigo": 400, "mensaje": "CONEXION FALLO", "respuesta": ""}';
    } else {

        if (isset($_GET['nickname']) && isset($_GET['score']) && isset($_GET['date'])) {
            $nick_name = $_GET['nickname'];
            $score = $_GET['score'];
            $date = $_GET['date'];
            $sql = "INSERT INTO `Puntaje` (`idPuntaje`, `nick_name`, `score`, `date`) VALUES (NULL, '" . $nick_name . "', '" . $score . "', '" . $date . "');";
            if ($conn->query($sql) === TRUE) {
                echo '{"codigo": 201, "mensaje": "Puntaje registrado con exito", "respuesta": ""}';
            } else {
                echo '{"codigo": 402, "mensaje": "ERROR: puntaje no registrado", "respuesta": ""}';
            }
        } else {
            echo '{"codigo": 401, "mensaje": "ERROR: faltan datos para guardar puntaje", "respuesta": ""}';
        }



    }
} catch (\Throwable $th) {
    echo '{"codigo": 400, "mensaje": "ERROR, NO SE PUEDE ESTABLECER LA CONEXION", "respuesta": ""}';
}