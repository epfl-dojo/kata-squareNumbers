<?php

$size = $argv[1];

function row($size){
  print " row : $size * $size\n";
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
  print " column : $size * $size\n";
  $total = $size * $size;
  $counter = $size;

  for ($i=1; $i <= $total ; $i++) {
    print sprintf(" %'.02d"," $i");
    $current = $i;
    for ($j=1; $j <= $counter ; $j++) {
      $current += $size;
      print sprintf(" %'.02d"," $current");
      if($counter == $size) {
        print "\n";
      }
    }
    $counter = 1;
  }
}

row($size);
print "\n\n\n";
column($size);
