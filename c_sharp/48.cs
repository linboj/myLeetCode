public class Solution {
    public void Rotate(int[][] matrix) {
        
        Transpose(matrix);
        FlipX(matrix);
    }

    private void FlipX(int[][] matrix){
        int nCol = matrix[0].Length;
        for (int r = 0; r < matrix.Length; r++ ){
            for (int c = 0; c < nCol / 2; c++){
                int temp = matrix[r][c];
                matrix[r][c] = matrix[r][nCol - c - 1];
                matrix[r][nCol - c - 1] = temp;
                // (matrix[r][c], matrix[r][nCol - c - 1]) = (matrix[r][nCol - c - 1], matrix[r][c]);
            } 
        }
    }
    private void Transpose(int[][] matrix) {
        for (int r = 0; r < matrix.Length; r++ ){
            for (int c = r; c < matrix[0].Length; c++){
                int temp = matrix[r][c];
                matrix[r][c] = matrix[c][r];
                matrix[c][r] = temp;
                // (matrix[r][c], matrix[c][r]) = (matrix[c][r], matrix[r][c]);
            }
        }
    }
}