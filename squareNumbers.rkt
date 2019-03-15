#lang racket
(require dyoo-while-loop)
;;(define size (λ (size) (make-string size #\*)))
(define display-line (λ(str) (display (string-append str "\n" ))))
(display-line "Entrer la taille du carré:")
(define size (string->number (read-line (current-input-port))))

(define border_up_right (λ(size) (* size size)))
 
 ;; 3x3          5x5
;; 7 8 9    21 22  23  24 (25)
;; 6 1 2    20 07  08 (09) 10
;; 5 4 3    19 06 (01) 02  11
;;          18 05  04  03  12
;;          17 16  15  14  13

(define s3 '#(#(7 8 9)
              #(6 1 2)
              #(5 4 3)))

(define s5 '#(#(21 22 23 24 25)
              #(20 07 08 09 10)
              #(19 06 01 02 11)
              #(18 05 04 03 12)
              #(17 16 15 14 13)))

(define display-matrix (λ (m)
  (for ([l m])
    (for ([n l])
      (display(~r n #:min-width 2 #:pad-string "0"))
      (display " "))
    (displayln ""))))

(display-matrix s3)

; (define multiplie-liste (λ (l size) (for/list ([i size]) (struct-copy l)))) 



(define mkmatrix (λ(size)  (build-vector size (λ (x) (build-vector size (λ (x) 0))))))

(define matrix-set! (λ(m coords v)
                      (let ((x (vector-ref coords 0))
                            (y (vector-ref coords 1)))
                            (vector-set! (vector-ref m y) x v))))
                      ;m[x,y]=v

(define advance! ( λ (m c s) ()))

(define spirale (
                 λ (size) (
                           let ((m (mkmatrix size))
                                (coords (vector (- size 1) 0))
                                (step (vector -1 0))
                                (z (* size size)))
                            
                            (while (> z 0)    
                                   (matrix-set! m coords z)
                                   (advance! m coords step)
                            )
                            
;                            (for/and ([i (in-range (* size size))])
                            forn if x!0 then x=x-1
                            (while ())
                            
                            (displayln (- size i))
                              (or ()) ;; When this is false, loop stops)
                            
                            m)))


(display-matrix (spirale size))

(define test (and (equal? (spirale 5) s5) (equal? (spirale 3) s3 )))
test

