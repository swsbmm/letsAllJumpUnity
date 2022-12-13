<?php
include 'header.php';
try {
    $conn = mysqli_connect($servidor, $usuario, $password, $baseDatos);

    if (!$conn) {
        echo '{"codigo": 400, "mensaje": "CONEXION FALLO", "respuesta": ""}';
    } else {

        $sql = "SELECT nick_name, score, date FROM Puntaje";
        $resultado = $conn->query($sql);
        $texto = '';
        while ($row = $resultado->fetch_assoc()) {
            $texto .=  "{#nick_name#: " . $row['nick_name'] . ",#score#: " . $row['score'] . ", #date#: " . $row['date'] . "}";
        }


        echo '{"codigo": 202, "mensaje": "PUNTAJES", "respuesta": "' . $texto . '"}';





    }
} catch (\Throwable $th) {
    echo '{"codigo": 400, "mensaje": "ERROR, NO SE PUEDE ESTABLECER LA CONEXION", "respuesta": ""}';
}

include 'footer.php';