public class Robot
{

    private int _width;
    private int _height;
    private int _perimeter;
    private bool moved;
    private int _pos;

    public Robot(int width, int height)
    {
        _width = width - 1;
        _height = height - 1;
        _perimeter = (_width + _height) * 2;
    }

    public void Step(int num)
    {
        moved = true;
        _pos = (num + _pos) % _perimeter;
    }

    public int[] GetPos()
    {
        if (_pos <= _width) return [_pos, 0];
        if (_pos <= _width + _height) return [_width, _pos - _width];
        if (_pos <= _width * 2 + _height) return [_width * 2 + _height - _pos, _height];
        return [0, _perimeter - _pos];
    }

    public string GetDir()
    {
        if (!moved) return "East";
        if (_pos == 0) return "South";
        if (_pos <= _width) return "East";
        if (_pos <= _width + _height) return "North";
        if (_pos <= 2 * _width + _height) return "West";
        return "South";
    }
}

/**
 * Your Robot object will be instantiated and called as such:
 * Robot obj = new Robot(width, height);
 * obj.Step(num);
 * int[] param_2 = obj.GetPos();
 * string param_3 = obj.GetDir();
 */