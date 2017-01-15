       $set ilusing "OpenTK.Graphics.OpenGL".
       $set ilusing "OpenTK".
       $set ilusing "System.Drawing".

       class-id Planets.Render is partial
           inherits type GameWindow.
      * /////////////////////////////////////////////////////////////////////////////////////////////////////////////
       working-storage section.
           77 rtri             Type Double value is 0.
           77 rquad            Type Double value is 0.

       method-id new.
       local-storage section.
       linkage section.
           77 w                type Int32.
           77 h                type Int32.
       procedure division using w, h.
           invoke super::new(w,h).
           
           move 100 to self::X.
           move 100 to self::Y.
           
           invoke type GL::ShadeModel(type ShadingModel::Smooth).                               *> enable smooth shading
           invoke type GL::ClearColor(0.0, 0.0, 0.0, 0.5).                            *> black background
           invoke type GL::ClearDepth(1.0).                                              *> depth buffer setup
           invoke type GL::Enable(type EnableCap::DepthTest).                                   *> enables depth testing
           invoke type GL::DepthFunc(type DepthFunction::Lequal).                               *> type Of depth test
           invoke type GL::Hint(type HintTarget::PerspectiveCorrectionHint, type HintMode::Nicest).   *> nice perspective calculations
           
           goback.
       end method.

       
      * /////////////////////////////////////////////////////////////////////////////////////////////////////////////  

      *> Automatically inserted Methods from OpenTK.GameWindow


       method-id OnLoad override protected.
       local-storage section.
           77 ans              type Double value is 0.
       procedure division using by value e as type System.EventArgs.
           invoke super::OnLoad(e).
           
           invoke type GL::MatrixMode(type MatrixMode::Projection).

           compute ans = self::Width / self::Height.
           invoke type GL::LoadMatrix(type Matrix4::Perspective(45.0, ans, 0.1, 5000.0)).
           invoke type GL::MatrixMode(type MatrixMode::Modelview).
           invoke type GL::LoadIdentity().
       end method.
       
      * /////////////////////////////////////////////////////////////////////////////////////////////////////////////  
       method-id OnResize override protected.
       local-storage section.
           77 ans              type Double value is 0.
       procedure division using by value e as type System.EventArgs.
           invoke super::OnResize(e).
           
           compute ans = self::Width / self::Height.
           invoke type GL::Viewport(ClientRectangle).
           invoke type GL::LoadMatrix(type Matrix4::Perspective(45.0, ans, 0.1, 5000.0))
           invoke type GL::MatrixMode(type MatrixMode::Modelview)
       
       end method.
       
      * /////////////////////////////////////////////////////////////////////////////////////////////////////////////   
       method-id OnKeyDown override protected.
       procedure division using by value e as type OpenTK.Input.KeyboardKeyEventArgs.
           invoke super::OnKeyDown(e).
           
           if e::Key = type OpenTK.Input.Key::Escape
               invoke self::Exit()
           end-if.
       end method.
       
      * /////////////////////////////////////////////////////////////////////////////////////////////////////////////   
       method-id OnRenderFrame override protected.
       procedure division using by value e as type OpenTK.FrameEventArgs.
           invoke super::OnRenderFrame(e).

           invoke type GL::Clear(type ClearBufferMask::ColorBufferBit B-Or type ClearBufferMask::DepthBufferBit).
           invoke type GL::ClearColor(type Color::Black).

           invoke type GL::MatrixMode(type MatrixMode::Modelview).
           invoke type GL::LoadIdentity().
           invoke type GL::Translate(-1.5, 0.0, -6.0).
           invoke type GL::Rotate(rtri, 0.0, 1.0, 0.0).
           
           invoke type GL::Begin(type PrimitiveType::Triangles).
           invoke type GL::Color3(type Color::Red).             *>Red
           invoke type GL::Vertex3(0.0, 1.0, 0.0).            *>Top Of Triangle (Front)
           invoke type GL::Color3(type Color::Green).             *>green
           invoke type GL::Vertex3(-1.0, -1.0, 1.0).      *>left Of Triangle (front)
           invoke type GL::Color3(type Color::Blue).             *>blue
           invoke type GL::Vertex3(1.0, -1.0, 1.0).           *>right Of triangle (front)

           invoke type GL::Color3(type Color::Red).             *>red
           invoke type GL::Vertex3(0.0, 1.0, 0.0).            *>top Of triangle (right)
           invoke type GL::Color3(type Color::Blue).             *>blue
           invoke type GL::Vertex3(1.0, -1.0, 1.0).           *>left Of triangle (right)
           invoke type GL::Color3(type Color::Green).             *>green
           invoke type GL::Vertex3(1.0, -1.0, -1.0).      *>right Of triangel (right)

           invoke type GL::Color3(type Color::Red).             *>red
           invoke type GL::Vertex3(0.0, 1.0, 0.0).            *>top Of triangle (back)
           invoke type GL::Color3(type Color::Green).             *>green
           invoke type GL::Vertex3(1.0, -1.0, -1.0).      *>left Of triangle (back)
           invoke type GL::Color3(type Color::Blue).             *>blue
           invoke type GL::Vertex3(-1.0, -1.0, -1.0).         *>right Of triangle (back)

           invoke type GL::Color3(type Color::Red).             *>red
           invoke type GL::Vertex3(0.0, 1.0, 0.0).            *>top Of triangle (left)
           invoke type GL::Color3(type Color::Blue).             *>blue
           invoke type GL::Vertex3(-1.0, -1.0, -1.0).         *>left Of triangle (left)
           invoke type GL::Color3(type Color::Green).             *>green
           invoke type GL::Vertex3(-1.0, -1.0, 1.0).      *>right Of triangle (left)
           invoke type GL::End().
           add .17 to rtri giving rtri.

           invoke type GL::LoadIdentity().                     *>reset the current modelview matrix
           invoke type GL::Translate(1.5, 0.0, -7.0).      *>move 1.5 Units right And 7 into the screen
           invoke type GL::Rotate(rquad, 1.0, 1.0, 1.0).       *>rotate the quad On the X,Y And Z-axis
           add -.15 to rquad giving rquad.                         *>rotation angle

           invoke type GL::Begin(type PrimitiveType::Quads).              *>start drawing a quad
           invoke type GL::Color3(type Color::Green).             *>green top
           invoke type GL::Vertex3(1.0, 1.0, -1.0).           *>top right (top)
           invoke type GL::Vertex3(-1.0, 1.0, -1.0).      *>top left (top)
           invoke type GL::Vertex3(-1.0, 1.0, 1.0).           *>bottom left (top)
           invoke type GL::Vertex3(1.0, 1.0, 1.0).            *>bottom right (top)

           invoke type GL::Color3(type Color::Orange).             *>orange
           invoke type GL::Vertex3(1.0, -1.0, 1.0).           *>top right (bottom)
           invoke type GL::Vertex3(-1.0, -1.0, 1.0).      *>top left (bottom)
           invoke type GL::Vertex3(-1.0, -1.0, -1.0).         *>bottom left (bottom)
           invoke type GL::Vertex3(1.0, -1.0, -1.0).      *>bottom right (bottom)

           invoke type GL::Color3(type Color::Red).             *>red
           invoke type GL::Vertex3(1.0, 1.0, 1.0).            *>top right (front)
           invoke type GL::Vertex3(-1.0, 1.0, 1.0).           *>top left (front)
           invoke type GL::Vertex3(-1.0, -1.0, 1.0).      *>bottom left (front)
           invoke type GL::Vertex3(1.0, -1.0, 1.0).           *>bottom right (front)

           invoke type GL::Color3(type Color::Yellow).                 *>yellow
           invoke type GL::Vertex3(-1.0, 1.0, -1.0).      *>top right (back)
           invoke type GL::Vertex3(1.0, 1.0, -1.0).           *>top left (back)
           invoke type GL::Vertex3(1.0, -1.0, -1.0).      *>bottom left (back)
           invoke type GL::Vertex3(-1.0, -1.0, -1.0).         *>bottom right (back)

           invoke type GL::Color3(type Color::Blue).             *>blue
           invoke type GL::Vertex3(-1.0, 1.0, 1.0).           *>top right (left)
           invoke type GL::Vertex3(-1.0, 1.0, -1.0).      *>top left (left)
           invoke type GL::Vertex3(-1.0, -1.0, -1.0).         *>bottom left (left)
           invoke type GL::Vertex3(-1.0, -1.0, 1.0).      *>bottom right (left)

           invoke type GL::Color3(type Color::Violet).             *>violett
           invoke type GL::Vertex3(1.0, 1.0, -1.0).           *>top right (right)
           invoke type GL::Vertex3(1.0, 1.0, 1.0).            *>top left (right)
           invoke type GL::Vertex3(1.0, -1.0, 1.0).       *>bottom left (right)
           invoke type GL::Vertex3(1.0, -1.0, -1.0).      *>bottom right (right)
           invoke type GL::End().
           
           invoke self::SwapBuffers().
       end method.
       
      *> End Methods from OpenTK.GameWindow

       end class.
