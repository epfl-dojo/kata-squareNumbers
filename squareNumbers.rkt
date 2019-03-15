#lang racket
(require dyoo-while-loop)

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

(define solution3 '#(#(7 8 9)
              #(6 1 2)
              #(5 4 3)))

(define solution5 '#(#(21 22 23 24 25)
              #(20 07 08 09 10)
              #(19 06 01 02 11)
              #(18 05 04 03 12)
              #(17 16 15 14 13)))

;; taille = log_10
(define display-matrix (λ (m)
                         (let* ((size (vector-length m))
                                (last-n (* size size))
                                (print-size (+ 1 (exact-floor (log last-n 10)))))
                           (for ([l m])
                             (for ([n l])
                               (display(~r n #:min-width print-size #:pad-string "0"))
                               (display " "))
                             (displayln "")))))

;; Pour tester :
; (display-matrix solution3)


(define mkmatrix (λ(size)  (build-vector size (λ (x) (build-vector size (λ (x) 0))))))

(define matrix-set! (λ(m coords v)
                      (let ((x (vector-ref coords 0))
                            (y (vector-ref coords 1)))
                            (vector-set! (vector-ref m y) x v))))

(define matrix-get (λ(m coords)
                      (let ((x (vector-ref coords 0))
                            (y (vector-ref coords 1)))
                            (vector-ref (vector-ref m y) x))))

(define turn! (λ (dir)
                (cond ((equal? dir '#(-1 0))
                       (vector-copy! dir 0 '#(0 1)))

                      ((equal? dir '#(0 1))
                       (vector-copy! dir 0 '#(1 0)))

                      ((equal? dir '#(1 0))
                       (vector-copy! dir 0 '#( 0 -1)))

                      ((equal? dir '#(0 -1))
                       (vector-copy! dir 0 '#(-1 0))))))

(define exn:fail:contract:vector-ref? (λ (e)
  (and (exn:fail:contract? e)
       (equal? "vector-ref" (substring (exn-message e) 0 10)))))

(define advance! ( λ (m c s)
                    (let ((size (vector-length m))
                          (c+s (vector-map + c s))
                          (wall -1))
                     (if (= 0 (with-handlers ([exn:fail:contract:vector-ref?
                                               (λ (e) wall)])
                                (matrix-get m c+s)))
                      (vector-copy! c 0 c+s) ; if true
                      (begin 
                        (turn! s)           ; else
                        (advance! m c s)))))) ; else recall advance...
  


(define spirale (
                 λ (size) (
                           let ((m (mkmatrix size))
                                (coords (vector (- size 1) 0))
                                (step (vector -1 0))
                                (z (* size size)))
                            
                            (while (> z 0)    
                                   (matrix-set! m coords z)
                                   (when (= z 1) (break))
                                   (advance! m coords step)
                                   (set! z (- z 1)))
                            m)))


(display-matrix (spirale size))

;;;;;;;;;;;;;;;;; Le programme est fini, merci pour votre attention.
;;;;;;;;;;;;;;;;; Ci-dessous : les tests unitaires.
(define test (and
              (equal? solution5 (spirale 5))
              (equal? solution3 (spirale 3))))
test
