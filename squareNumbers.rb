# ruby squareNumbers.rb SQUARE_SIZE
# This is base on Zuzu's analysis of the square:
# - First line (z=0) contains the last set of s numbers
# - Last line (z=s-1) contains ~ the 3rd set of s numbers in reverse order
# - Second line (z=1):
#   * first element is the one above - 1
#   * the S-2 next elements are the first line of Box of size S-2
#   * the last element is the one on its left + 1
# - Other lines (1 < z < s-1):
#   * first element is the one above - 1
#   * the S-2 next elements are the (z-1) line of  the Box of size S-2
#   * the last element is the one above + 1
# 
# S = 5
# 21 22 23 24 25 
# 20 07 08 09 10 
# 19 06 01 02 11 
# 18 05 04 03 12 
# 17 16 15 14 13 
#
# S = 6
# 31 32 33 34 35 36 
# 30 13 14 15 16 17 
# 29 12 03 04 05 18 
# 28 11 02 01 06 19 
# 27 10 09 08 07 20 
# 26 25 24 23 22 21 

def mline(s,y,lm1)
    # puts "---> #{s}   #{y}  #{lm1 ? lm1.join(',') : 'nil'}"
    l = []
    if y == 0
        l = Array((s*(s-1)+1)..s*s)
    elsif y == s-1
        l = Array((s*s - 3*s + 3)..(s*s - 2*s + 2)).reverse
    else
        l[0] = lm1[0]-1
        l = l + mline(s-2, y-1, lm1[1..(s-2)])
        if y==1
            l[s-1] = l[s-2] + 1
        else
            l[s-1] = lm1[s-1] + 1
        end
    end
    # puts "<--- #{s}   #{y}  #{l.join(',')}"
    l
end  

def square(s)
    pad=Math.log10(s*s+1).to_i+1
    puts "pad=#{pad}"
    lm1=nil
    for y in 0..s-1
      l = mline(s, y, lm1)
      ls = l.map{|v| sprintf("%0#{pad}d", v)}
      puts ls.join(" ")
      lm1 = l
    end
end

square ARGV[0].to_i
