<?php
/* Attempt MySQL server connection. Assuming you are running MySQL
server with default setting (user 'root' with no password) */
$link = mysqli_connect("localhost", "root", "1234", "pap");
 
// Check connection
if($link === false){
    die("ERROR: Could not connect. " . mysqli_connect_error());
}
 
// Attempt select query execution
$sql = "SELECT * FROM users";
if($result = mysqli_query($link, $sql)){
    if(mysqli_num_rows($result) > 0){
        echo "<table>";
            echo "<tr>";
                echo "<th>ID</th>";
                echo "<th>UTILIZADOR</th>";
                echo "<th>RUA</th>";
                echo "<th>EMAIL</th>";
				echo "<th>DATA REGISTO</th>";
            echo "</tr>";
        while($row = mysqli_fetch_array($result)){
            echo "<tr>";
                echo "<td>" . $row['userId'] . "</td>";
                echo "<td>" . $row['userName'] . "</td>";
                echo "<td>" . $row['userRua'] . "</td>";
                echo "<td>" . $row['userEmail'] . "</td>";
				echo "<td>" . $row['userRegisto'] . "</td>";
            echo "</tr>";
        }
        echo "</table>";
        // Close result set
        mysqli_free_result($result);
    } else{
        echo "No records matching your query were found.";
    }
} else{
    echo "ERROR: Could not able to execute $sql. " . mysqli_error($link);
}
 
// Close connection
mysqli_close($link);
?>