<?php

$size = $argv[1];

function row($size){
  print " row: $size * $size\n";
  $total = $size * $size;
  $current = $size;
  for ($i=1; $i <= $total; $i++) {
    print sprintf(" %'.02d"," $i");
    if($i == $current) {
      $current += $size;
      print "\n";
    }
  }
}

function column($size){
  print " column: $size * $size\n";
  $total = $size * $size;
  $counter = $size;
  for ($i=1; $i <= $size ; $i++) {
    print sprintf(" %'.02d"," $i");
    $current = $i;
    for ($j=1; $j < $counter ; $j++) {
      $current += $size;
      print sprintf(" %'.02d"," $current");
    }
    print"\n";
  }
}

function spiral($size){
  $square = $size * $size;
  $array = [];
  for($i = 0; $i < $size; $i++) {
    $array[$i] = [];
    for($j = 0; $j < $size; $j++) {
      $array[$i][$j] = 0;
    }
  }

  $x = $size -1;
  $y = 0;

  $dx = -1;
  $dy = 0;

  for($i = $square; $i > 0; $i--) {
    $array[$y][$x] = "$i $x $y";
    
    $new_x = $x + $dx;
    $new_y = $y + $dy;

    if ($new_x >= 0 && $new_x < $size && $new_y >= 0 && $new_y < $size && !($array[$new_y][$new_x])){
      $x = $new_x;
      $y = $new_y;
    } else {
      $res = turn($dx, $dy);
      $dx = $res[0];
      $dy = $res[1];
      
      $x = $x + $dx;
      $y = $y + $dy;
    }
  }

  // print_r($array);
  echo (" spiral: $size * $size\n");
  foreach($array as $line) {
    foreach($line as $v) {
      printf(" %02d", $v);
    }
    printf("\n");
  }
}

function turn($dx, $dy){
  if ($dx === 0 && $dy === -1) {            // UP
    $dx = -1;                               // LEFT
    $dy = 0;
  } elseif ($dx === 1 && $dy === 0) {       // RIGHT
    $dx = 0;                                // UP
    $dy = -1;
  } elseif ($dx === 0 && $dy === 1) {       // DOWN
    $dx = 1;                                // RIGHT
    $dy = 0;
  } elseif($dx === -1 && $dy === 0) {       // LEFT
    $dx = 0;                                // DOWN
    $dy = 1;
  } else {
    die('yolo');
  }

  return [$dx, $dy];
}


row($size);
print "\n\n";
column($size);
print "\n\n";
spiral($size);
